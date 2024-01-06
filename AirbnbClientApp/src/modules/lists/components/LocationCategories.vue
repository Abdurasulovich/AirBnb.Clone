<template>
  <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">
    <location-category-card v-for="location in locationCategories" :locationCategory="location"/>
  </div>
</template>
<script setup lang="ts">
import LocationCategoryCard from "@/modules/lists/components/LocationCategoryCard.vue";
import {LocationCategory} from "@/modules/lists/models/LocationCategory";
import {onBeforeMount, ref} from "vue";
import {AirBnbApiClient} from "@/infrastructures/apiClients/airBnbApiClient/AirBnbApiClient";
const airBnbApiClient = new AirBnbApiClient();
const  locationCategories = ref<LocationCategory[]>([]);
onBeforeMount(async()=>{
  const locationsResponse = await airBnbApiClient.locationCategories.getAsync();
  locationCategories.value = locationsResponse.response!;
})
</script>