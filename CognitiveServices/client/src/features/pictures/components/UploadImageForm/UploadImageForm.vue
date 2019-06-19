<template>
    <FormCard> 
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
                v-model='picture.categoryIds'
                :items="categories"
                multiple label="Categories"
                prepend-icon='description'
            />
            <v-select 
                item-value='id'
                item-text='name'
                v-model='picture.subCategoryIds'
                :items="subCategories"
                multiple label="Subcategories"
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
    </FormCard>
</template>

<script>
import { createNamespacedHelpers } from 'vuex';  

import FormCard from '../../../../common/components/form';
import { GET_CATEGORIES, GET_SUBCATEGORIES, getSubcategoriesActions } from '../../../../common/store/categories/actions';
const { mapActions, mapState } = createNamespacedHelpers('category');

export default {
    name: 'uploadImageForm',    
    components: {
        FormCard
    },
    computed: {
        ...mapState(['categories', 'subCategories']),
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
            categoryIds: [],
            subCategoryIds: []
        },
        url: undefined
    }),
    methods: {
        uploadFile(e) {
            const reader = new FileReader();

            this.picture.file = e.target.files[0];

            reader.onload = e => {
                this.url = e.target.result;
            }
            
            reader.readAsDataURL(e.target.files[0]);
            
            // this.picture.file = e.target.files[0];
            // this.url = URL.createObjectURL(this.picture.file);
        },
        submit() {
            const { subCategoryIds, ...rest} = this.picture;
            const picture = {
                ...rest,
                categoryIds: [...rest.categoryIds, ...subCategoryIds]
            }

            this.$emit('submit', picture);
        },
         ...mapActions([
            GET_CATEGORIES.DEFAULT
        ])
    },
    watch: {
        populateWith: function(val) {
            if(!this.populateWith.empty) {
                this.picture = { ...val };

                this.url = `data:image/png;base64, ${val.content}`;
            }    
        },
        ['picture.categoryIds']: {
            handler: function(ids) {  
                this.$store.dispatch(`category/${GET_SUBCATEGORIES.DEFAULT}`, { ids }, { root: true });
            },
            deep: true,
            immediate: false,
        }
    },
    mounted() {
        this.$store.dispatch(`category/${GET_CATEGORIES.DEFAULT}`, {}, { root: true });
    }
}
</script>

<style>
    .upload-image-form {
        margin-top: 15%
    }
</style>
