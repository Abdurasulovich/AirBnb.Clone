<template>
  <div
    class="mt-[160px] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6 gap-x-4 gap-y-10 place-items-center">

    <location-card v-for="location in locations" :location="location"/>
  </div>
</template>
<script setup lang="ts">
import LocationCard from "@/modules/lists/components/LocationCard.vue";
import {AirBnbApiClient} from "@/infrastructures/apiClients/airBnbApiClient/AirBnbApiClient";
import {onBeforeMount, ref} from "vue";

const airBnbApiClient = new AirBnbApiClient();
const locations = ref<Location[]>([]);

onBeforeMount(async ()=>{
  const locationsResponse = await airBnbApiClient.locations.getAsync();
  locations.value = locationsResponse.response!;

  console.log(locations);
})
</script>