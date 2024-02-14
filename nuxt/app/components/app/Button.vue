<template>
<Button>
    <slot name="icon-prefix"></slot>
    <slot />
    <slot name="icon-suffix"></slot>
</Button>
</template>

<style>
.p-button {
    @apply flex gap-1 items-center border rounded p-2 leading-none text-slate-500 transition hover:border-emerald-200 hover:bg-emerald-50 hover:text-emerald-600 active:border-emerald-500 active:bg-emerald-400 active:text-white;
}
</style>