import { createRouter, createWebHistory } from 'vue-router'
import ChatClient from '../ChatClient.vue'

const routes = [
    { path: '/chat', component: ChatClient }
]

export default createRouter({
    history: createWebHistory(),
    routes
})
