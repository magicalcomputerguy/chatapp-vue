<script setup>
import { ref, onMounted } from 'vue'
import * as signalR from '@microsoft/signalr'

const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7255/v1/hub')
    .withAutomaticReconnect()
    .build()

const messages = ref([])
const message = ref('')

onMounted(async () => {
    try {
        await connection.start()

        connection.on('ReceiveMessage', (user, msg) => {
            messages.value.push(`${user}: ${msg}`)
        })
    } catch (e) {
        console.error('SignalR connection error')
    }
})

async function sendMessage() {
    if (!message.value) {
        return
    }

    try {
        await connection.invoke('SendMessage', 'VueClient', message.value)
        message.value = ''
    } catch (e) {
        console.error(e)
    }
}
</script>

<template>
    <div style='padding:20px;'>
        <h2>Vue + SignalR Chat</h2>

        <div
            style='
                border:1px solid #ccc;
                padding:10px;
                height:200px;
                overflow-y:auto;
                margin-bottom:10px;
            '
        >
            <div v-for='(m, i) in messages' :key='i'>
                {{ m }}
            </div>
        </div>

        <input
            v-model='message'
            placeholder='Write a message.'
            style='padding:6px; width:70%;'
            @keyup.enter='sendMessage'
        />

        <button @click='sendMessage' style='padding:6px 12px; margin-left:8px;'>
            Send
        </button>
    </div>
</template>
