<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="container pt-2">
    <nav class="d-flex gap-3 justify-content-evenly">
      <RouterLink class="btn btn-outline-success w-25" to="/">Home</RouterLink>
      <RouterLink class="btn btn-outline-success w-25" to="/about">About</RouterLink>
    </nav>
  </div>

  <RouterView />
</template>

<style scoped></style>
