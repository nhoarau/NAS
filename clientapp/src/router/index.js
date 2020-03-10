import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from './routes'
import { SessionStorage } from 'quasar'

Vue.use(VueRouter)

const Router = new VueRouter({
  mode: 'history',
  base: process.env.VUE_ROUTER_BASE,
  scrollBehavior: () => ({ y: 0 }),
  routes
})

// Declaration du SessionStorage qui sera accessible dans toute l'appli
SessionStorage.set('isAuth', false)

Router.beforeEach((to, from, next) => {
  if (to.matched.some(route => route.meta.requiresAuth)) {
    console.log('route' + to.matched.some(route => route.meta.requiresAuth))
    console.log(SessionStorage.getItem('isAuth'))
    if (SessionStorage.getItem('isAuth') === true) {
      next()
    } else {
      next({ path: '/login' })
    }
  }
  next()
})

export default Router
