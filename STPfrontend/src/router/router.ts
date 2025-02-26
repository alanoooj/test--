import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: () => import('@/views/Login.vue'),
    },
    {
      path: '/sign-up',
      name: 'SignUp',
      component: () => import('@/views/SignUp.vue'),
    },
    {
      path: '/',
      name: 'main',
      component: () => import('@/views/Home.vue'),
    },
    {
      path: '/Password-change',
      name: 'passwordChange',
      component: () => import('@/views/ChangePassword.vue'),
    },
    {
      path: '/friends',
      name: 'friends',
      component: () => import('@/views/Friends.vue'),
    },
    {
      path: '/Landing-Page',
      name: 'landingPage',
      component: () => import('@/views/LandingPage.vue'),
    },
  ],
});

export default router;
