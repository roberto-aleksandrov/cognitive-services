<template>
  <v-container fill-height>
      <v-layout row wrap align-center justify-center>
        <v-flex class="text-xs-center" xs6>
            <!-- <Form> 
                <h2 slot='header' class='green--text text--darken-2'>Upload Image</h2>
                <v-form class='px-3' slot='content'>
                    <v-text-field label='Title' color='green' v-model='title' prepend-icon='title'></v-text-field>
                    <v-textarea label='Description' color='green' v-model='description' prepend-icon='description'></v-textarea>
                    <v-layout row>
                        <v-btn flat color='green' @click="$refs.inputUpload.click()">image</v-btn>
                        <input v-show="false" ref="inputUpload" type="file" @change="setFile"></input>
                        <v-img v-if='url' :src='url'  aspect-ratio='2'>

                         </v-img>
                    </v-layout>
                    <v-card-actions class="justify-center">
                        <v-btn flat class='success mt-4' @click='submit'>Upload</v-btn>
                    </v-card-actions>
                </v-form>
            </Form> -->
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
        // setFile(e) {
        //     e.preventDefault();
        //     this.file = e.target.files[0];
        //     this.url = URL.createObjectURL(this.file);
        // },
        submit(data) {
            // const data = {
            //     title: this.title,
            //     description: this.description,
            //     content: file,
            // };
    console.log(data);
            this.$store.dispatch(`createPicture/${CREATE_PICTURE.DEFAULT}`, data, { root: true })
        },
        ...mapActions([
            CREATE_PICTURE.DEFAULT
        ])
    },
    mounted() {
        // this.$store.dispatch(`createPicture/${CREATE_PICTURE.DEFAULT}`, {}, { root: true })
    }
}
</script>

<style>

</style>
