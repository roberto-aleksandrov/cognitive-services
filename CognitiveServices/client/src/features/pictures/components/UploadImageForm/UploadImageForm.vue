<template>
    <Form> 
        <h2 slot='header' class='green--text text--darken-1'>Upload Image</h2>
        <v-form class='px-3' slot='content'>
            <v-text-field 
                label='Title'
                color='green'
                v-model='picture.title'
                prepend-icon='title'
            />
            <v-select 
                item-value='id'
                item-text='name'
                @change='selectChange' 
                :items="categories"
                multiple label="Categories"
                prepend-icon='description'
            />
            <v-textarea 
                label='Description' 
                color='green' 
                v-model='picture.description' 
                prepend-icon='description'
            />
            <v-layout row>
                <v-btn 
                    flat 
                    color='green'
                    @click="$refs.inputUpload.click()">
                        image
                </v-btn>
                <input 
                    v-show="false"
                    ref="inputUpload" 
                    type="file" @change="uploadFile"
                />
                <v-img
                    v-if='url'
                    :src='url'
                    aspect-ratio='2'
                />
            </v-layout>
            <v-card-actions class="justify-center">
                <v-btn 
                flat class='success mt-4' 
                @click='submit'>
                    Upload
                </v-btn>
            </v-card-actions>
        </v-form>
    </Form>
</template>

<script>
import { createNamespacedHelpers } from 'vuex';  

import Form from '../../../../common/components/form';
import { GET_CATEGORIES } from '../../../../common/store/categories/actions';
const { mapActions, mapState } = createNamespacedHelpers('category');

export default {
    name: 'uploadImageForm',    
    components: {
        Form
    },
    computed: {
        ...mapState(['categories']),
    },
    props: {
        populateWith: {
            type: Object,
            default: () => ({ empty: true })
        }
    },
    data: () => ({
        picture: {
            name: '',
            description: '',
            file: undefined,
            categoryIds: []
        },
        url: undefined
    }),
    methods: {
        selectChange(e) {
            this.picture.categoryIds = e;            
        },
        uploadFile(e) {
            this.picture.file = e.target.files[0];
            this.url = URL.createObjectURL(this.picture.file);
        },
        submit() {
            console.log('here');
            this.$emit('submit', this.picture);
        },
         ...mapActions([
            GET_CATEGORIES.DEFAULT
        ])
    },
    created() {
        if(!this.populateWith.empty) {
            this.picture = this.populateWith;
        }
    },
    mounted() {
        this.$store.dispatch(`category/${GET_CATEGORIES.DEFAULT}`, {}, { root: true });
    }
}
</script>

<style>

</style>
