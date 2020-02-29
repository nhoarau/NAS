
const routes = [
  {
    path: '/',
    component: () => import('pages/Login.vue'),
    children: [
      { name: 'main', path: '/main', component: () => import('pages/Main.vue') }
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
