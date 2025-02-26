<template>
  <div class="w-64 h-screen bg-white shadow-md flex flex-col p-4">
    <!-- Profile Section -->
    <div class="flex items-center mb-8">
      <div
        class="w-16 h-16 bg-gray-300 border border-black flex items-center justify-center"
      >
        <span class="text-gray-500">🖼</span>
      </div>
      <div class="ml-4 text-gray-800">
        <div class="font-medium">Vorname</div>
        <div class="font-medium">Nachname</div>
      </div>
    </div>

    <!-- Navigation Links -->
    <nav class="space-y-6">
      <button class="flex items-center text-gray-900 text-lg font-bold">
        <span class="mr-4">🏠</span>
        <router-link to="/">Dashboard</router-link>
      </button>
      <button class="flex items-center text-gray-900 text-lg font-bold">
        <span class="mr-4">💬</span>
        <router-link to="/chat">Nachrichten</router-link>
      </button>
      <button
        class="flex items-center text-gray-900 text-lg font-bold underline"
      >
        <span class="mr-4">📅</span>
        <router-link to="/calendar">Kalender</router-link>
      </button>
      <button
        class="flex items-center text-gray-900 text-lg font-bold underline"
      >
        <span class="mr-4">👤</span>
        <router-link to="/friends"> Freunde</router-link>
      </button>
    </nav>
  </div>
</template>
<script lang="ts"></script>
