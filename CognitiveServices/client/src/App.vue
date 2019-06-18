<template>
  <v-app>
    <v-content>
       <v-toolbar
        absolute
        color="green"
        dark
        scroll-off-screen
        scroll-target="#scrolling-techniques"
      >
        <v-toolbar-title>Cognitive Services</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn flat to="/pictures/create">Create Picture</v-btn>
        <v-btn flat to="/pictures">Pictures</v-btn>
        <v-btn flat to="/about">Abuot</v-btn>
      </v-toolbar>
        <router-view></router-view>
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
