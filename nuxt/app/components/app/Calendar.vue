<script lang="ts" setup>
defineProps({
    modelValue: {
        type: Date,
        required: true
    },
    showIcon: { 
        type: Boolean,
        required:  false,
        default: false
    }
})
const emits = defineEmits(['update:modelValue'])
const handleUpdate = (value: Date) => {
    emits('update:modelValue', value)
}
</script>

<template>
<Calendar :modelValue="modelValue" @update:modelValue="handleUpdate" :showIcon="showIcon">
    <template #inputicon>
        <Icon name="ph:user" />
    </template>
</Calendar>
</template>

<style>
.p-calendar {
    @apply border rounded text-slate-500 flex focus-within:border-emerald-400;
}

.p-calendar .p-inputtext {
    @apply outline-none px-2 rounded-l;
}

.p-calendar .p-button {
    @apply border-none gap-0 outline-none outline-offset-0 outline-1 active:bg-emerald-400 hover:outline hover:outline-emerald-400 focus:outline focus:outline-emerald-400;
}

.p-calendar .p-button .p-button-label {
    @apply hidden;
}

.p-datepicker {
    @apply border rounded bg-white text-slate-500 min-w-[14rem] shadow-md translate-y-1 p-1;
}

.p-datepicker-header {
    @apply flex items-center leading-none;
}

.p-datepicker-header .p-datepicker-prev,
.p-datepicker-header .p-datepicker-next {
    @apply px-2 py-1 transition hover:bg-slate-100 hover:text-slate-500;
}

.p-datepicker-header .p-datepicker-prev {
    @apply rounded-tl;
}

.p-datepicker-header .p-datepicker-next {
    @apply rounded-tr;
}

.p-datepicker-title {
    @apply flex flex-grow justify-center gap-2;
}

.p-datepicker-calendar {
    @apply w-full;
}

.p-datepicker-calendar [data-pc-section='tableheaderrow'] {
    @apply border-b border-slate-200 text-slate-600;
}

.p-datepicker-calendar [data-pc-section='tableheadercell'] {
    @apply w-[calc(100%/7)];
}

.p-datepicker-calendar .p-disabled {
    @apply opacity-25 pointer-events-none;
}

.p-datepicker-calendar [data-pc-section='day'] {
    @apply text-center px-1 py-2 leading-none;
}

.p-datepicker-calendar [data-pc-section='day']:not([data-p-other-month='true']) {
    @apply cursor-pointer rounded hover:bg-slate-100;
}

.p-datepicker-calendar .p-datepicker-today[data-pc-section='day']:not([data-p-other-month='true']) {
    @apply bg-slate-400 text-white hover:bg-slate-500;
}

.p-datepicker-calendar .p-datepicker-current-day {
    @apply bg-emerald-400 hover:bg-emerald-600;
}

.p-monthpicker {
    @apply grid grid-cols-4;
}

.p-monthpicker-month {
    @apply text-center leading-none px-1 py-2 cursor-pointer rounded hover:bg-slate-100;
}

.p-monthpicker-month[data-p-disabled='true'] {
    @apply opacity-25 pointer-events-none;
}

.p-yearpicker {
    @apply grid grid-cols-4;
}

.p-yearpicker-year {
    @apply text-center leading-none px-1 py-2 cursor-pointer rounded hover:bg-slate-100;
}

.p-yearpicker-year[data-p-disabled='true'] {
    @apply opacity-25 pointer-events-none;
}
</style>