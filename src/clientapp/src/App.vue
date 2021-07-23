<template>
  <div class="page-container md-layout-row">
    <Appbar />
  </div>
</template>


<script>

import Appbar from '@/components/Appbar.vue'

export default {
  name: 'App',
  components: {
    Appbar
  },
  methods: {
    onMenuClicked: function(menuItem){
      this.title = menuItem;
    }
  }
}

</script>



<style scoped>


.md-app{
  height: 750px!important;
}


</style>
