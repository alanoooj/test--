<template>
  <div class="p-6 bg-white border border-black">
    <div class="space-y-2">
      <div
        class="flex border border-black divide-x"
        v-for="event in events"
        :key="event.id"
      >
        <div class="flex-1 p-2 font-bold">{{ event.date }}</div>
        <div class="p-2">{{ event.time }}</div>
        <div class="flex-1 p-2">{{ event.sport }}</div>
        <div class="p-2">💬 {{ event.comments }}</div>
        <div class="p-2 flex items-center">
          ✅ {{ event.wins }} ✖ {{ event.losses }} ❔{{ event.unknown }}
        </div>
        <div class="flex-1 p-2">{{ event.player }}</div>
      </div>
    </div>
    <div class="mt-4 text-right text-red-600 font-bold underline">
      <a href="#">Alle anzeigen (27)</a>
    </div>
  </div>
</template>

<script lang="ts">
export default {
  data() {
    return {
      events: [
        {
          id: 1,
          date: '18.02.2025',
          time: '17:00 Uhr',
          sport: 'Fussball',
          comments: 2,
          wins: 3,
          losses: 10,
          unknown: 2,
          player: 'Mef',
        },
        {
          id: 2,
          date: '01.03.2025',
          time: '12:45 Uhr',
          sport: 'Tennis',
          comments: 12,
          wins: 17,
          losses: 3,
          unknown: 2,
          player: 'Alex',
        },
        {
          id: 3,
          date: '17.03.2025',
          time: '13:00 Uhr',
          sport: 'Golf',
          comments: 17,
          wins: 4,
          losses: 2,
          unknown: 0,
          player: 'Jason',
        },
        {
          id: 4,
          date: '01.04.2025',
          time: '18:00 Uhr',
          sport: 'Laufen',
          comments: 1,
          wins: 19,
          losses: 7,
          unknown: 1,
          player: 'Mef',
        },
        {
          id: 5,
          date: '16.04.2025',
          time: '09:45 Uhr',
          sport: 'Billiard',
          comments: 0,
          wins: 2,
          losses: 10,
          unknown: 12,
          player: 'Hakoon',
        },
      ],
    };
  },
};
</script>
