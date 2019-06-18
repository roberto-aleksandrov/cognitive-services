<template>
  <v-container fill-height>
      <v-layout row wrap align-center justify-center>
        <v-flex class="text-xs-center" xs6>
            <UploadImageForm :populateWith='picture' v-on:submit='submit($event)'></UploadImageForm>
        </v-flex>   
      </v-layout>  
  </v-container>
</template>

<script>
import { createNamespacedHelpers } from 'vuex';  
import { GET_PICTURE, GET_PICTURES } from '../../../common/store/pictures';
import { UPDATE_PICTURE } from './store';
import UploadImageForm from '../components/UploadImageForm';

const { mapActions, mapState } = createNamespacedHelpers('picture');

export default {
    name: 'updatePicturePage',
    components: {
        UploadImageForm
    },  
    computed: {
        ...mapState(['picture']),
    },
    methods: {
        submit(data) {
            this.$store.dispatch(`updatePicture/${UPDATE_PICTURE.DEFAULT}`, data, { root: true })
        },
        ...mapActions([
            UPDATE_PICTURE.DEFAULT
        ])
    },
    mounted() {
        this.$store.dispatch(`picture/${GET_PICTURE.DEFAULT}`, {id: this.$route.params.id}, { root: true });
    }
}
</script>

<style>

</style>
