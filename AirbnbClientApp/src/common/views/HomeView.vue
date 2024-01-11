<template>
  <!--Header-->
  <main-header/>

  <!--Content-->



  <button class="mt-40" @click="appThemeService.toggleDarkMode()">Dark mode</button>
</template>

<script setup lang="ts">
import MainHeader from "@/common/components/MainHeader.vue";
import LocationsContainer from "@/modules/lists/components/LocationsContainer.vue";
import {AppThemeService} from "@/infrastructures/services/AppThemeService";

const appThemeService = new AppThemeService();
</script>