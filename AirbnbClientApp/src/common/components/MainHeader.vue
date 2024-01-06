<template>
  <div
    class="fixed h-20 top-0 z-10 content-padding w-full bg-defaultBackground flex justify-between items-center border-b border-borderSecondary text-textPrimary">
    <!--Logo-->
    <main-logo/>

    <!--Locations menu-->
    <locations-menu/>

    <!--Profile menu-->
    <div></div>

    <!--Locations filter-->

    <!--Bottom border-->

    <div class="absolute border-b-2 border-borderSecondary"></div>
  </div>
</template>
<script setup lang="ts">
import MainLogo from "@/common/components/icons/MainLogo.vue";
import LocationsMenu from "@/modules/lists/components/LocationsMenu.vue";

</script>