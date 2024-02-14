<script lang="ts" setup>
defineProps({
    title: String,
    contentClass: String
})
</script>
<template>
<div class="flex flex-col gap-1">
    <span class="leading-none text-emerald-700 font-bold uppercase">{{ title }}</span>
    <div class="border rounded-md min-h-[10rem] shadow p-4" :class="[contentClass]">
        <slot />
    </div>
</div>
</template>