<template>
   <md-card class="md-default" md-with-hover>
      <md-card-content>
        <div class="input-container">
          <md-field>
          <md-input v-model="formattedTokens" readonly></md-input>
        </md-field>
        </div>
        <div class="input-container">
          <md-field>
            <md-input v-model="input" readonly></md-input>
          </md-field>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="reset($event)">
            C
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="execOperator($event, 'SE')">
            SE
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="execOperator($event, 'SN')">
            SN
          </md-button>
          <md-button class="md-raised md-accent divide" v-on:click="execOperator($event, '/')">
            /
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '7')">
            7
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '8')">
            8
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '9')">
            9
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="execOperator($event, '*')">
            <md-icon>close</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '4')">
            4
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '5')">
            5
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '6')">
            6
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="execOperator($event, '-')">
            <md-icon>remove</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '1')">
            1
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '2')">
            2
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="insertChar($event, '3')">
            3
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="execOperator($event, '+')">
            <md-icon>add</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent zero" v-on:click="insertChar($event, '0')">
            0
          </md-button>
          <md-button class="md-raised md-accent divide">
            -/+
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="evaluate($event)">
            <md-icon>drag_handle</md-icon>
          </md-button>
        </div>
      </md-card-content>
  </md-card>
</template>


<script>

import httpClient from '../services/http-client';
import isOperator  from './isOperator';
import rpn from './rpn';
import yard from './yard';
import format from './format';

export default {
  name: 'Calculator2',
  data: function() {
    return {
        loading: false,
        operator: "",
        showResult: false,
        tokens: [],
        formattedTokens: "",
        input: ""
    }
  },
  created: function() {
    window.addEventListener('keydown', this.keyDown);
    window.addEventListener('keyup', this.keyUp);
  },
  watch: {
    tokens: function() {
      //this.formattedTokens = this.getBeforeLastToken();
    }
  },
  methods: {
    keyDown: function(event) {
      var key = event.key.toLowerCase();
      
      if (key === 'c' || key === 'backspace') {
        this.reset(event);
      } else if (!isNaN(parseInt(key))) {
        this.insertChar(event, key);
      } else if (key === 'enter') {
        this.evaluate(event);
      } else if (isOperator(key)) {
        this.execOperator(event, key);
      }
    },
    keyUp: function(){
      //this.formattedTokens = this.tokens.map(format).join(' ').replace(/\*/g, 'x') || '0';
    
      //this.input = this.getInput();
    },
    getFormattedTokens: function(){
      return this.tokens ? this.tokens.map(format).join(' ').replace(/\*/g, 'x') || '0' : '';
    },
    getInput: function() {
      if (this.showResult) {
        try {
          //return format(math.eval(this.tokens.join(' ')).toString());
          return format(rpn(yard(this.tokens)).toString());
        } catch (e) {
          return 'you did something wrong.'
        }
      }

      return format(this.tokens
        .slice()
        .reverse()
        .find(t => !isOperator(t)) || '0');     
    },
    insertChar: function(e, character) {
      e.preventDefault();
      const lastToken = this.getLastToken();
      const doubleMin = lastToken === '-' && isOperator(this.getBeforeLastToken());

      if (lastToken === undefined || (isOperator(lastToken) && !doubleMin)) {
        if (character === '.') {
          character = '0' + character;
        }

        this.tokens.push(character);
      } else if (this.showResult) {
        this.tokens = [character];
      } else {
        this.tokens[this.tokens.length - 1] = lastToken + character;
      }

      this.showResult = false;
      this.setInput();
    },    
    execOperator: function(e, operator) {
      e.preventDefault();
      // ANS support
      if (this.showResult) {
        this.tokens = [rpn(yard(this.tokens)).toString()];
      }

      if (!this.getLastToken() && operator !== '(') {
        this.tokens.push('0');
      }

      if(this.operator && this.operator != operator);
      else {
        this.operator = operator;
        this.tokens.push(operator);
      }

      this.showResult = false;
      this.setInput();
    },
    evaluate: function(e) {
      e.preventDefault();
      if (this.showResult && this.tokens.length >= 2) {
        this.tokens = this.tokens.concat(this.tokens.slice(-2));
      }
     
      switch(this.operator){
        case "+":
          this.callApi("Add");
          break;
        case "-":
          this.callApi("Subtract");
          break;
        case "*":
          this.callApi("Multiply");
          break;
        case "/":
          this.callApi("Divide");
          break;
        case "SE":
          this.callApi("SplitEq");
          break;
        case "SN":
          this.callApi("SplitNum");
          break;
      }
    },
    reset: function(e){
      e.preventDefault();
      this.tokens = [];
      this.showResult = false;
      this.setInput();
    },
    setInput: function() {
      this.formattedTokens = this.tokens.map(format).join(' ').replace(/\*/g, 'x') || '0';
      this.input = this.tokens.map(format).join(' ').replace(/\*/g, 'x') || '0';
    }, 
    getLastToken: function(){
      return this.tokens[this.tokens.length - 1];
    },
    getBeforeLastToken: function() {
      return this.tokens[this.tokens.length - 2];
    },
    callApi: function(action) {
      this.loading = true;
      
      let payload = {
        calculation: this.tokens.join('')
      }
      if(action == "Divide" || action == "SplitEq"){
        payload = {
          param1: this.tokens[0],
          param2: this.tokens[2]
        }
      }

      httpClient
        .post(`api/Calculators/${action}`, payload)
        .then(
          response => {
            this.loading = false;
            const { data } = response;
            this.input = data;
            this.showResult = true; 
            this.operator = "";
          }
        );
    }
  }
}
</script>


<style scoped>

.input-container {
  width: 376px;
    margin: 6px 8px;
}

.zero {
  width: 184px;
}

.divide {
  font-weight: bold;
}

</style>
