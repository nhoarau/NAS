import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from './routes'
import { SessionStorage } from 'quasar'

Vue.use(VueRouter)
/*
 * If not building with SSR mode, you can
 * directly export the Router instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Router instance.
 */

const Router = new VueRouter({
  mode: 'history',
  base: process.env.VUE_ROUTER_BASE,
  scrollBehavior: () => ({ y: 0 }),
  routes
})
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
