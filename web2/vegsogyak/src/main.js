import './assets/main.css'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import 'vue-toastification/dist/index.css'

import { createApp, ref } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import  Toast from 'vue-toastification'

const app = createApp(App)

const options = ref({
    position: "top-right",
    closeOnClick: true,
    timeout: 1500
});

app.use(createPinia())
app.use(router)
app.use(Toast,options);

app.mount('#app')
