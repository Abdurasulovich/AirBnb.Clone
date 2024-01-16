<template>
  <article class="mt-[20px] text-textPrimaryDark content-padding">
    <div class="flex flex-col items-center justify-center">
      <!--locations tab-->
      <listings-tab @changeCategory="onChangeLists"/>

      <!--lists grid-->
      <lists-grid :lists="lists"/>



    </div>
  </article>
</template>
<script setup lang="ts">
import {onBeforeMount, ref} from "vue";
import ListingsTab from "@/modules/lists/components/ListingsTab.vue";
import {AirbnbApiClient} from "@/infrastructure/apiClients/airbnbApiClient/brokers/AirbnbApiClient";
import {Listing} from "@/modules/models/Listing";
import {list} from "postcss";
import type {Guid} from "guid-typescript";
import ListsGrid from "@/modules/lists/components/ListsGrid.vue";

const airbnbApiClients = new AirbnbApiClient();
const lists =ref<Listing[]>([]);

onBeforeMount(async ()=>{
  await loadListsAsync();
})

const loadListsAsync = async ()=>{
  const listsResponse = await airbnbApiClients.listing.getAsync();
  if(listsResponse.isSuccess){
    lists.value = listsResponse.response!;
  }
}

const onChangeLists = async (id: Guid)=>{
  const listsResponse = await airbnbApiClients.listing.getByCategoryId(id);
  if(listsResponse.isSuccess)
    lists.value = listsResponse.response!;
}
</script>