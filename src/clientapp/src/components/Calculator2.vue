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
          <md-button class="md-raised md-accent" v-on:click="onClearClicked()">
            C
          </md-button>
          <md-button class="md-raised md-accent">
            SplitEq
          </md-button>
          <md-button class="md-raised md-accent">
            SplitNum
          </md-button>
          <md-button class="md-raised md-accent divide" v-on:click="onDivideClicked()">
            /
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(7)">
            7
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(8)">
            8
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(9)">
            9
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onMultiplyClicked()">
            <md-icon>close</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(4)">
            4
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(5)">
            5
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(6)">
            6
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onSubtractClicked()">
            <md-icon>remove</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(1)">
            1
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(2)">
            2
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onNumberClicked(3)">
            3
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onAddClicked()">
            <md-icon>add</md-icon>
          </md-button>
        </div>
        <div>
          <md-button class="md-raised md-accent zero" v-on:click="onNumberClicked(0)">
            0
          </md-button>
          <md-button class="md-raised md-accent divide">
            -/+
          </md-button>
          <md-button class="md-raised md-accent" v-on:click="onEqualClicked()">
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
      
    }
  },
  methods: {
    keyDown: function(event) {
      var key = event.key.toLowerCase();
      event.preventDefault();
      
      if (key === 'c' || key === 'backspace') {
        this.reset();
      } else if (key === ',' || key === '.') {
        this.insertChar('.');
      } else if (!isNaN(parseInt(key))) {
        this.insertChar(key);
      } else if (key === 'enter') {
        this.evaluate();
      } else if (isOperator(key)) {
        this.execOperator(key);
      }
    },
    keyUp: function(){
      this.formattedTokens = this.tokens.map(format).join(' ').replace(/\*/g, 'x') || '0';
    
      //this.input = this.getInput();
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
    insertChar: function(character) {
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
    },    
    execOperator: function(operator) {
      // ANS support
      if (this.showResult) {
        this.tokens = [rpn(yard(this.tokens)).toString()];
      }

      if (!this.getLastToken() && operator !== '(') {
        this.tokens.push('0');
      }

      this.tokens.push(operator);
      this.showResult = false;
    },
    evaluate: function() {
      // repeat last action
      if (this.showResult && this.tokens.length >= 2) {
        this.tokens = this.tokens.concat(this.tokens.slice(-2));
      }

      var numbers = [];
      //let operator = this.tokens[1];
      for(var index = 0; index < this.tokens.length; index++){
        if(!isNaN(parseInt(this.tokens[index])))
          numbers.push(this.tokens[index] * 1);
      
      }

    },
    reset: function(){
      this.tokens = [];
      this.showResult = false;
      this.input = "0";
    },
    onNumberClicked: function(number) {
      this.input += number;
      this.numbers.push(number);
    },
    onClearClicked: function() {
      this.input = "";
      this.result = "";
      this.numbers = [];
    },
    onAddClicked: function() {
      this.input += "+";
    },
    onSubtractClicked: function() {
      this.input += "-";
    },
    onMultiplyClicked: function() {
      this.input += "*";
    },
    onDivideClicked: function() {
      this.input += "/";
    }, 
    getLastToken: function(){
      return this.tokens[this.tokens.length - 1];
    },
    getBeforeLastToken: function() {
      return this.tokens[this.tokens.length - 2];
    },
    onEqualClicked: function() {
      this.input += "=";
      console.log('submit:')
      
      
      this.loading = true;


      httpClient
        .post("api/Calculators/Add", { calculation: this.numbers.join(',') })
        .then(
          response => {
            const { data } = response;
            this.result = data;
            this.input += data;
          }
        );

  
      
    },
    addApi: function() {

      this.loading = true;
      httpClient
        .post("api/Calculators/Add", { calculation: this.tokens })
        .then(
          response => {
            this.loading = false;
            const { data } = response;
            console.log(data);
            this.input = data;
            this.showResult = true; 

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
