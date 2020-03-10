const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { name: 'login', path: '/login', component: () => import('pages/Login.vue') },
      { name: 'main', path: '/main', component: () => import('pages/Main.vue') },
      // { name: 'main', path: '/main', component: () => import('pages/Main.vue'), meta: { requiresAuth: true } },
      { name: 'sideBar', path: '/sideBar', component: () => import('components/SideBar.vue') }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes
