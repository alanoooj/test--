<template>
  <div
    class="flex flex-col items-center justify-center min-h-screen bg-gray-100"
  >
    <div class="bg-white p-8 rounded-lg shadow-lg w-96">
      <h1 class="text-2xl font-bold text-center mb-6">Sign Up</h1>
      <div class="space-y-4">
        <input
          v-model="newUserEmail"
          type="text"
          placeholder="Email"
          class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          v-model="newUserPassword"
          type="password"
          placeholder="Passwort"
          class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          v-model="newUserName"
          type="text"
          placeholder="Name"
          class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <!-- <button
          @click="saveUser"
          class="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition duration-200"
        >
          Sign in
        </button> -->
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
//import { useUsersStore } from '../stores/userStore';
import { ref } from 'vue';

//const usersStore = useUsersStore();

const newUserEmail = ref('');
const newUserPassword = ref('');
const newUserName = ref('');

/*function saveUser() {
  if (!newUserEmail.value) {
    return;
  }
  usersStore.saveNewUser(
    newUserName.value,
    newUserEmail.value,
    newUserPassword.value
  );
}*/
</script>
