<template>
   <md-card class="md-default" md-with-hover>
      <md-card-content>
        <div class="input-container">
          <md-field>
          <md-input v-model="input"></md-input>
        </md-field>
        </div>
        <div class="input-container">
          <md-field>
            <md-input v-model="result" disabled=""></md-input>
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

const isOperator = function(token) {
  return token === '-' || token === '+' || token === '*' || token === '/' || token === 'SplitEq' || token === 'SplitNum';
}

export default {
  name: 'Calculator',
  data: function() {
    return {
        loading: false,
        showResult: false,
        input: "",
        tokens: [],
        numbers: [],
        operators: [],
        result: ""
    }
  },
  created: function() {
    window.addEventListener('keydown', this.keyDown);
  },
  methods: {
    keyDown: function(event) {
      var key = event.key.toLowerCase();
      
      event.preventDefault();
      
      if (key === 'c' || key === 'backspace') {
        this.onClearClicked();
      } else if (!isNaN(parseInt(key))) {
        var number = parseInt(key);
        this.onNumberClicked(number);
      } else if (key === 'enter') {
        this.onEqualClicked();
      } else if (this.isOperator(key)) {
        if(this.numbers.length == 0) 
          return false;

        switch(key){
          case "+":
            this.onAddClicked();
            break;
          
          case "-":
            this.onSubtractClicked();
            break;            

          case "*":
            this.onMultiplyClicked();
            break;
            
          case "/":
            this.onDivideClicked();
            break;

        }
      }
    },
    insertChar: function(character) {
      const lastToken = this.lastToken;
      const doubleMin = lastToken === '-' && isOperator(this.beforeLastToken);

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
    }
    
    ,
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
    isOperator: function(token) {
      return token === '-' || token === '+' || token === '*' || token === '/' || token === 'SplitEq' || token === 'SplitNum';
    }, 
    getLastToken: function(){
      return this.tokens[this.tokens.length - 1];
    },
    beforeLastToken() {
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
