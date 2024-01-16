<template>

  <!--Lists categories previous pagination-->
  <div class="fixed w-full top-0 pt-2 mt-20 z-10 theme-bg-primary flex items-center justify-center gap-4 content-padding dark:shadow">
    <div class="mb-3 theme-text-primary">
      <button class="border theme-border h-8 w-8 flex items-center justify-center rounded-full hover-shadow">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
             style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
          <path fill="none" d="M20 28 8.7 16.7a1 1 0 0 1 0-1.4L20 4"></path>
        </svg>
      </button>
    </div>

        <list-categories/>

    <!--Lists categories next pagination-->
      <div class="mb-3 theme-text-primary">
        <button class="border theme-border h-8 w-8 flex items-center justify-center rounded-full hover-shadow">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation"
               focusable="false"
               style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
            <path
                fill="none" d="m12 4 11.3 11.3a1 1 0 0 1 0 1.4L12 28"></path>
          </svg>
        </button>
      </div>

    <!--Filters actions-->
    <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">
      <!--Locaitons filter-->
      <button class="ml-3 flex group h-12 w-auto px-4 theme-border justify-center items-center rounded-lg gap-3">
        <svg class="theme-text-secondary select-text"
             xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"
             aria-hidden="true"
             role="presentation"
             focusable="false"
             style="display: block; fill: none; height: 16px; width: 16px; stroke: currentcolor; stroke-width: 4; overflow: visible;">
          <path fill="none"
                d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
        </svg>
        <span class="theme-text-primary">Filters</span>
      </button>

      <button class="ml-3 flex group h-12 w-auto px-4 theme-border justify-center items-center rounded-lg gap-3">
        <span class="text-xs font-medium whitespace-nowrap theme-text-primary">Display total before taxes</span>
          <lists-filter v-model="toggleState"/>
      </button>
    </div>
  </div>
</template>
<script lang="ts">
import ListCategories from "@/modules/lists/components/ListCategories.vue";
import ListsFilter from "@/modules/lists/components/ListsFilter.vue";
export default{
  components:{ListCategories, ListsFilter},
  data(){
    return{
      toggleState: false
    }
  }
}
</script>
