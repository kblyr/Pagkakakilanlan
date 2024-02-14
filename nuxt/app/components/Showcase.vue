<script lang="ts" setup>

const calendar_value = ref<Date>(new Date())

</script>

<template>
<div class="flex flex-col p-4 gap-4">
    <span class="text-emerald-700 text-center bg-emerald-50 leading-none p-4 border border-emerald-200 rounded text-2xl">Showcasing customized <span class="font-bold">PrimeVue</span> Components</span>
    <ShowcaseItem title="Button" content-class="flex flex-wrap gap-2 items-start">
        <AppButton>Click Me</AppButton>
        <AppButton>
            <template #icon-prefix>
                <Icon name="ph:arrow-left" />
            </template>
            Click Me
        </AppButton>
        <AppButton>
            Click Me
            <template #icon-suffix>
                <Icon name="ph:check" />
            </template>
        </AppButton>
        <AppButton>
            <template #icon-prefix>
                <Icon name="ph:arrow-left" />
            </template>
            Click Me
            <template #icon-suffix>
                <Icon name="ph:check" />
            </template>
        </AppButton>
    </ShowcaseItem>
    <ShowcaseItem title="Calendar" content-class="flex flex-wrap gap-2 items-start">
        <AppCalendar v-model="calendar_value" :show-icon="true" />
    </ShowcaseItem>
</div>
</template>