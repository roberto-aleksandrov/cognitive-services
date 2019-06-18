<template>
    <v-container class='mt-5'>
        <v-layout class='mt-5' row wrap>
            <v-flex v-for='picture in pictures' v-bind:key='picture.id' class='mt-5' xs10 md3 offset-sm1>
                <v-card>
                    <v-img 
                    :src='`data:image/png;base64, ${picture.content}`'
                    aspect-ratio='2'
                    ></v-img>

                    <v-card-title primary-title>
                    <div>
                        <h3 class='headline mb-0'>{{picture.title}}</h3>
                        <div>{{picture.description}}</div>
                    </div>
                    </v-card-title>

                    <v-card-actions>
                    <v-btn flat color='orange' v-on:click='handleUpdate(picture.id)'>Edit</v-btn>
                    <v-btn flat color='orange' v-on:click='handleDelete(picture.id)'>Delete</v-btn>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>      
</v-container>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'; 

import { GET_PICTURES, DELETE_PICTURE } from '../../../common/store/pictures';

const { mapActions, mapState } = createNamespacedHelpers('picture');

export default {
    name: 'picturesPage',    
    computed: {
        ...mapState(['pictures'])
    },
    methods: {
        handleUpdate: function(id) {
            this.$router.push(`/pictures/update/${id}`);
        },
        handleDelete: function(id) {
            this.$store.dispatch(`picture/${DELETE_PICTURE.DEFAULT}`, { id }, { root: true });    
        },
        ...mapActions([
            DELETE_PICTURE
        ])
    },
    mounted() {
        this.$store.dispatch(`picture/${GET_PICTURES.DEFAULT}`, {}, { root: true });
    }
}
</script>

<style scoped>
    .pictures-container {
        margin-top: 200px;
    }
</style>
