<template>
    <md-app>
      <md-app-toolbar class="md-primary">
        <span class="md-title">{{title}}</span>
      </md-app-toolbar>

      <md-app-drawer md-permanent="full">
        <md-toolbar class="md-transparent" md-elevation="0">
           <md-button class="md-icon-button">
            <md-icon>menu</md-icon>
            
          </md-button>Calculator
        </md-toolbar>

        <md-list>
          <md-list-item to="/">
            <md-icon>home</md-icon>
            <span class="md-list-item-text">Home</span>
          </md-list-item>
          <md-list-item to="/about" v-on:click="onMenuClicked('Home')">
            <md-icon>add</md-icon>
            <span class="md-list-item-text">Add</span>
          </md-list-item>
          <md-list-item to="/Subtract">
            <md-icon>remove</md-icon>
            <span class="md-list-item-text">Subtract</span>
          </md-list-item>

          <md-list-item to="/Multiply">
            <md-icon>close</md-icon>
            <span class="md-list-item-text">Multiply</span>
          </md-list-item>

          <md-list-item to="/Divide">
            <md-icon>error</md-icon>
            <span class="md-list-item-text">Divide</span>
          </md-list-item>
        </md-list>
      </md-app-drawer>

      <md-app-content>
        <router-view></router-view>
      </md-app-content>
    </md-app>
</template>


<script>
export default {
  name: 'Appbar',
  data: function() {
      return {
          title: "Home"
      }
  },
  methods: {
      onMenuClicked: function(menuItem) {
          this.title = menuItem;
      }
  }
}
</script>

<style scoped>


.md-app {
    min-height: 350px;
    border: 1px solid rgba(#000, .12);
  }

  .md-drawer {
    width: 230px;
    max-width: calc(100vw - 125px);
  }

</style>
