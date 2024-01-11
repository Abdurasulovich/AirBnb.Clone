<template>
  <div class="h-[80px] select-common group min-w-[50px] flex flex-col justify-center items-center">
    <img :src="locationCategory.imagePath"
         class="h-[24px] w-[24px] mb-2 opacity-60 select-opacity primary-transition"
          alt="Lists category selected icon">
    <h5 class="text-xs theme-text-primary-icon font-medium opacity-60 select-opacity primary-transition">{{locationCategory.name}}</h5>
    <div class="w-3/5 h-[2px] select-item primary-transition"></div>
  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";
import type {ListingCategory} from "@/modules/models/ListingCategory";

const props = defineProps({
  locationCategory:{
    type: Object as ()=>ListingCategory,
    required: true
  }
})
</script>
<script lang="ts">
export default {
  methods:{
    toggleTheme(){
      const isDarkMode = true;

      const myIcon = this.$refs.myIcon

      if(isDarkMode){
        myIcon.setAttribute('fill','white');
      }else {
        myIcon.setAttribute('fill', 'black');
      }
    },
  },
};
</script>
