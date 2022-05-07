import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  loading: false,
  theme: false,
  user: {},
  account: {},
  games: [],
  activeGame: {},
  categories: {},
  searchCategories: [],
  accountLeagues: {},
  gameQueue: [],
  matchSettings: {
    ranked: false,
    games: [],
  }
})
