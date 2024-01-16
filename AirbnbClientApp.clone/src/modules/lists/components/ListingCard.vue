<template>
  <div class="rounded-xl">
    <!--Lists header-->
    <div class="w-full h-auto aspect-square rounded-xl overflow-hidden relative">
      <img class="h-full  object-cover" aria-hidden="true" loading="eager"
           :src="list.imageUrl" data-orginal-url="https://a0.muscache.com/im/pictures/miso/Hosting-46086331/original/381be40f-472a-4415-bee8-f33c76a43945.jpeg?im_w=720"
           style="--dls-liteimage-object-fit: cover;">
      <button class="absolute top-4 right-4">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
             style="display: block; fill: rgba(0, 0, 0, 0.5); height: 24px; width: 24px;  stroke-width: 2; overflow: visible;">
          <path stroke="white" d="M16 28c7-4.73 14-10 14-17a6.98 6.98 0 0 0-7-7c-1.8 0-3.58.68-4.95 2.05L16 8.1l-2.05-2.05a6.98 6.98 0 0 0-9.9 0A6.98 6.98 0 0 0 2 11c0 7 7 12.27 14 17z"></path>
        </svg>
      </button>
    </div>

    <!--Lists details-->
    <div class="flex justify-between mt-2">
      <div class="basis-2/3">
        <h5 class="font-medium line-clamp-1 theme-text-primary">{{list.name}}</h5>
        <p class="theme-text-primary">{{list.builtYear}}</p>
        <p class="theme-text-primary">{{list.freeDate}}</p>
        <h5 class="theme-text-primary">
          <strong>${{list.pricePerNight}}</strong> night
        </h5>
      </div>

      <!--Feedback-->
      <div class="flex items-start justify-center">
        <div class="flex gap-2 items-center justify-center">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
               style="display: block; height: 12px; width: 12px; fill: currentcolor;">
            <path class="theme-text-primary-icon"
                  d="m15.1 1.58-4.13 8.88-9.86 1.27a1 1 0 0 0-.54 1.74l7.3 6.57-1.97 9.85a1 1 0 0 0 1.48 1.06l8.62-5 8.63 5a1 1 0 0 0 1.48-1.06l-1.97-9.85 7.3-6.57a1 1 0 0 0-.55-1.73l-9.86-1.28-4.12-8.88a1 1 0 0 0-1.82 0z"></path>
          </svg>
          <span class="theme-text-primary">{{list.feedBack}}</span>
        </div>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import type {Listing} from "@/modules/models/Listing";

const props =defineProps({
  list:{
    type:Object as ()=>Listing,
    required: true
  }
})
</script>