<template>
  <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">
    <list-category-card v-for="location in listCategories" :locationCategory="location" :selected-category-id="selectedCategoryId" :key="location.id" @change="onChangeLocation"/>
  </div>
</template>
<script setup lang="ts">
import {AirbnbApiClient} from "@/infrastructure/apiClients/airbnbApiClient/brokers/AirbnbApiClient";
import {onBeforeMount, ref} from "vue";
import type {ListingCategory} from "@/modules/models/ListingCategory";
import ListCategoryCard from "@/modules/lists/components/ListCategoryCard.vue";
import {Guid} from "guid-typescript";

const airbnbApiClient = new AirbnbApiClient();
const listCategories = ref<ListingCategory[]>([]);
const selectedCategoryId = ref<Guid>();
onBeforeMount(async ()=>{
  const listsResponse = await airbnbApiClient.listingCategory.getAsync();
  listCategories.value = listsResponse.response!;
})

const emit = defineEmits<{changeCategory:[id:Guid]}>();

const onChangeLocation = (id: Guid)=>{
  selectedCategoryId.value =id;
  emit('changeCategory', id)
}
</script>