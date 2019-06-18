<template>
  <v-container fill-height>
      <v-layout row wrap align-center justify-center>
        <v-flex class="text-xs-center" xs6>
            <UploadImageForm v-on:submit='submit($event)'></UploadImageForm>
        </v-flex>   
      </v-layout>  
  </v-container>
</template>

<script>
import { createNamespacedHelpers } from 'vuex';  
import { CREATE_PICTURE } from './store/actions';
import UploadImageForm from '../components/UploadImageForm';

const { mapActions } = createNamespacedHelpers('createPicture');

export default {
    name: 'createPicturePage',
    components: {
        UploadImageForm
    },
    methods: {
        submit(data) {
            this.$store.dispatch(`createPicture/${CREATE_PICTURE.DEFAULT}`, data, { root: true })
        },
        ...mapActions([
            CREATE_PICTURE.DEFAULT
        ])
    },
}
</script>

<style>

</style>
