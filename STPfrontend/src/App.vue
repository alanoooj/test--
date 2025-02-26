<template>
  <header></header>
  <main>
    <div class="flex flex-col items-center justify-center min-h-screen">
      <RouterView />
    </div>
  </main>
</template>
<script setup lang="ts">
import { RouterView } from 'vue-router';
</script>
