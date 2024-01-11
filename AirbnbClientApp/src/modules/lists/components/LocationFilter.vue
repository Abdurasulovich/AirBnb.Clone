<template>
  <div :class="modelValue ? 'bg-logoSelected' : 'bg-gray-gray-300'" @click="toggle" class="w-[34px] h-[23px] transition-all duration-300 flex items-center justify-self-start bg-gray-300 rounded-full p-0.5 ">
    <div :class="{'translate-x-[10px]': modelValue}" class="w-[20px] h-[21px] rounded-full transition-all duration-300 transform bg-white shadow-md flex items-center justify-center">
      <svg :class="modelValue ? 'text-logoSelected' : 'text-white'" class="transition-all duration-300" viewBox="0 0 12 12" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" role="presentation"
           focusable="false" style="display: block;
           height: 12px; width: 12px; fill: currentcolor;">
        <path d="m10.5 1.939 1.061 1.061-7.061 7.061-.53-.531-3-3-.531-.53 1.061-1.061 3 3 5.47-5.469z"></path></svg>
    </div>
  </div>
</template>
<script>
import { ref } from 'vue';

export default {
  name: "LocationFilter",
  props: {
    modelValue: {
      type: Boolean
    }
  },
  methods:{
    toggle(){
      console.log(!this.modelValue)
      this.$emit('update:modelValue', !this.modelValue)
    }
  }

};
</script>
