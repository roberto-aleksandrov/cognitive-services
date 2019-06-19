<template>
  <v-app>
    <v-content>
       <v-toolbar
        absolute
        color="green"
        dark
        scroll-off-screen
        scroll-target="#scrolling-techniques"
        class='navigation'
      >
        <v-toolbar-title>Cognitive Services</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn flat to="/pictures/create">Create Picture</v-btn>
        <v-btn flat to="/">Pictures</v-btn>
        <v-btn flat to="/about">Abuot</v-btn>
      </v-toolbar>
        <router-view class='main-container'></router-view>
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App',
  data () {
    return {
      //
    }
  }
}
</script>

<style>
  .navigation {
    position: fixed;
  }

  html {
    overflow: hidden;
  }

  main.v-content {
    width: 100vw;
    height: calc(100vh - 64px);
    flex-direction: column;
    overflow: scroll;
    margin-top: 64px;
    padding-top: 0 !important;
  }
</style>

