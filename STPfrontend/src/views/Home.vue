<template>
  <div class="w-full fixed top-0 left-0 bg-white shadow-md z-50">
    <Navbar />
  </div>
  <div class="flex mt-20 h-screen w-full">
    <SideBar />
    <div class="bg-white flex mr-2"><DashboardSideBar /></div>

    <div
      class="flex-1 flex flex-col items-center bg-white bg-opacity-30 p-8 rounded-lg shadow-md"
    >
      <div class="w-full"><DashboardFrinendBox /></div>
      <div class="w-full mt-2"><DashboardCalendarBox /></div>
    </div>
  </div>
</template>

<script setup lang="ts">
import Navbar from '@/components/NavBar.vue';
import DashboardCalendarBox from '@/components/DashboardCalendarBox.vue';
import DashboardFrinendBox from '@/components/DashboardFrinendBox.vue';
import DashboardSideBar from '@/components/DashboardSideBar.vue';
import SideBar from '@/components/SideBar.vue';
</script>
