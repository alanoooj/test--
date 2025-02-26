<template>
  <aside
    :class="is_expanded ? 'w-64' : 'w-16'"
    class="h-screen bg-gray-800 text-white transition-all duration-300 flex flex-col p-4"
  >
    <div class="flex justify-between items-center w-full">
      <!-- <span class="text-lg font-semibold">Dashboard</span> -->
      <button
        @click="toggleMenu"
        class="text-white text-2xl transform transition-transform"
        :class="is_expanded ? 'rotate-180' : ''"
      >
        &#x21C0;
      </button>
    </div>
    <div v-if="is_expanded" class="mt-4">
      <div class="flex space-x-2">
        <!-- <input
          v-model="newProject"
          type="text"
          placeholder="Neue Projekt"
          class="flex-1 p-2 rounded-lg text-black"
          @keyup.enter="addProject"
        />
        <button
          @click="addProject"
          class="p-2 bg-blue-500 rounded-lg text-white"
        >
          +
        </button> -->
      </div>
      <ul class="mt-4 space-y-2">
        <!-- <li
          v-for="project in projects"
          :key="project.title"
          class="flex justify-between items-center p-2 bg-gray-700 rounded-lg"
        >
          <span>{{ project.title }}</span>
          <button @click="Store.deleteProject(project.id)" class="text-red-500">
            🗑
          </button>
        </li> -->
      </ul>
    </div>
  </aside>
</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { ref } from 'vue';
// import { useProjectStore } from '../stores/projectStore';

const is_expanded = ref(false);
// const Store = useProjectStore();
// Store.getProject();
// const { projects } = storeToRefs(Store);
// const newProject = ref('');

// function addProject() {
//   if (!newProject.value) return;
//   Store.addNewProject(newProject.value);
//   newProject.value = '';
// }

const toggleMenu = () => {
  is_expanded.value = !is_expanded.value;
};
</script>
