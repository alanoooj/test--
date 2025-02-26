<template>
  <div
    class="flex flex-col items-center justify-center min-h-screen bg-gray-100"
  >
    <div class="bg-white p-8 rounded-lg shadow-lg w-96">
      <h1 class="text-2xl font-bold text-center mb-6">Login</h1>
      <div class="space-y-4">
        <input
          v-model="username"
          type="text"
          placeholder="Username"
          class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          v-model="userPassword"
          type="password"
          placeholder="Passwort"
          class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <button
          type="submit"
          class="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition duration-200"
          @click="login"
        >
          Login
        </button>
      </div>
      <div class="mt-4 text-center flex flex-col items-center">
        <router-link class="text-blue-500 hover:underline" to="/sign-up">
          Haben Sie kein Konto?
        </router-link>
        <router-link class="text-blue-500 hover:underline" to="/Password-change"
          >passwort vergesen?</router-link
        >

        <br />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import router from '@/router/router';
import { useUsersStore } from '@/stores/userStore';
import { ref } from 'vue';

const usersStore = useUsersStore();
const username = ref('');
const userPassword = ref('');

async function login() {
  usersStore.initializeStore();
  if (username.value == '' || userPassword.value == '') {
    return;
  }
  const loggrdIn = await usersStore.logUserIn(
    username.value,
    userPassword.value
  );
  if (loggrdIn) {
    router.push({ name: 'main' });
  }
  return;
  /*  const loggedin = await usersStore.logUserIn(
    userEmail.value,
    userPassword.value
  );
  console.log('logged in:', loggedin);

  if (loggedin) {
    router.push({ name: 'main' });
  }*/
}
</script>
