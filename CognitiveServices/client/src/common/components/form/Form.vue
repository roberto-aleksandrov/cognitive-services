<template>
    <v-card> 
        <v-card-title class='justify-center'>
            <slot name='header'></slot>
        </v-card-title>
        <v-card-text>
            <slot name='content'></slot>
        </v-card-text>
    </v-card>
</template>

<script>
export default {
    name: 'formCard'
}
</script>

<style>

</style>
