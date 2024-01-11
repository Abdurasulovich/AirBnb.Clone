<template>
  <div class="h-[80px] select-common group min-w-[50px] flex flex-col justify-center items-center">
    <img class="h-[24px] w-[24px] mb-2 select-logo-img select-transition"
         :src="locationCategory.imagePath"
         alt="Location selection icon">
    <h5 class="text-xs font-medium select-text select-transition whitespace-nowrap">{{locationCategory.name}}</h5>
    <div class="w-3/5 h-[2px] select-items select-transition"></div>
  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";
import type {LocationCategory} from "@/modules/lists/models/LocationCategory";

const props = defineProps({
  locationCategory:{
    type: Object as ()=>LocationCategory,
    required: true
  }
})
</script>