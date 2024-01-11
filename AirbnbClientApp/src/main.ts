import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import {AppThemeService} from "@/infrastructures/services/AppThemeService";

createApp(App).mount('#app')

const appThemeService  = new AppThemeService();

const app = createApp(App);
appThemeService.setAppTheme();
app.mount('#app')
