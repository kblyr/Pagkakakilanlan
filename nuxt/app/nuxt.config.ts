// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  modules: [
    'nuxt-icon',
    'nuxt-primevue',
    '@nuxtjs/tailwindcss'
  ],
  primevue: {
    unstyled: true
  }
})
