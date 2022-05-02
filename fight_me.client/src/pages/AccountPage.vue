<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { accountService } from "../services/AccountService"
export default {
  name: 'Account',
  setup() {
    onMounted(async() =>{
      try {
        await accountService.getAccount()
      } catch (error) {
        Pop.toast(error.message)
        logger.error(error)
      }
    })
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
