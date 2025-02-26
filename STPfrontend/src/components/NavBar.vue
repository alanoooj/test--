<template>
  <div class="flex justify-end items-center space-x-4 p-4">
    <router-link
      class="px-5 py-2 bg-blue-500 text-white rounded-full shadow-md hover:bg-blue-600 transition"
      to="/login"
    >
      Login
    </router-link>
    <router-link
      class="px-5 py-2 bg-red-500 text-white rounded-full shadow-md hover:bg-red-600 transition"
      to="/"
    >
      Logout
    </router-link>
  </div>
</template>

<script setup lang="ts"></script>
