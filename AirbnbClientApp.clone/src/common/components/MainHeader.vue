<template>

  <header class="w-full fixed h-20 top-0 z-10 flex justify-between items-center theme-bg-primary content-padding border-b theme-border">
    <!--main logo-->
    <main-logo/>

    <!--header menu-->
    <header-menu/>

    <!--dark mode-->
    <darkmode v-model="toggleState"/>

    <!--header home-->
    <header-home/>

    <!-- bottom border-->
    <div class="absolute border-b-2 border-borderSecondary"/>
  </header>
</template>
<script setup lang="ts">
import MainLogo from "@/common/components/icons/MainLogo.vue";
import HeaderMenu from "@/modules/lists/components/HeaderMenu.vue";
import HeaderHome from "@/modules/identity/components/HeaderHome.vue";
import Darkmode from "@/modules/lists/components/Darkmode.vue";
import {ref} from "vue";
const toggleState = ref(false)
</script>