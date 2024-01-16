<template>
  <div class="h-[80px] select-common group min-w-[50px] flex flex-col justify-center items-center">
    <img :src="locationCategory.imagePath"
         class="theme-category-icon h-[24px] w-[24px] mb-2 opacity-60 select-opacity primary-transition"
         :class="{'opacity-100':isCurrentCategorySelected}"
          alt="Lists category selected icon">
    <h5 class="text-xs theme-text-toggle-icon-sec opacity-60 select-opacity primary-transition"
         :class="{'text-black':isCurrentCategorySelected}">{{locationCategory.name}}</h5>
    <div class="w-3/5 h-[2px] select-item primary-transition"
         :class="{'bg-black opacity-100':isCurrentCategorySelected}"></div>
  </div>
</template>
<script setup lang="ts">
import {computed, defineProps, defineEmits} from "vue";
import type {ListingCategory} from "@/modules/models/ListingCategory";
import type {Guid} from "guid-typescript";

const props = defineProps({
  locationCategory:{
    type: Object as ()=>ListingCategory,
    required: true
  },
  selectedCategoryId:{
    type:Object as ()=>Guid,
    required: true
  }
});

const emit = defineEmits<{changeCategory:[id:Guid]}>();

const onChange = ()=>{
  emit('changeCategory', props.locationCategory.id)
}

const isCurrentCategorySelected = computed(()=>{
  return props.locationCategory.id === props.selectedCategoryId;
})
</script>
