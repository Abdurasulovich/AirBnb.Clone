<template>
  <div class="mt-[160px] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6 gap-x-4 gap-y-10 place-items-center">
    <listing-card v-for="list in lists" :list="list"/>
  </div>
</template>
<script setup lang="ts">
import type {PropType} from "vue";
import {defineProps} from "vue";
import type {Listing} from "@/modules/models/Listing";
import ListingCard from "@/modules/lists/components/ListingCard.vue";

const props = defineProps({
  lists:{
    type:Array as PropType<Array<Listing>>,
    required: true
  }
});
</script>