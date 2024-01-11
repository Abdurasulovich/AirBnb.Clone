<template>
  <header
    class="w-full fixed h-20 top-0 z-10 flex justify-between items-center theme-bg-primary content-padding border-b theme-border">
    <!--Logo-->
    <main-logo/>

    <!--Locations menu-->
    <header-menu/>

    <!--Profile menu-->
    <header-home/>

    <!--Locations filter-->
    <!--Bottom border-->
    <div class="absolute border-b-2 border-borderSecondary"></div>

  </header>
</template>
<script setup lang="ts">
import MainLogo from "@/common/components/icons/MainLogo.vue";
import HeaderMenu from "@/modules/lists/components/HeaderMenu.vue";
import HeaderHome from "@/modules/lists/Identity/Components/HeaderHome.vue";

</script>