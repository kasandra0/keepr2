<template>
    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser" class="col-10 offset-1 col-sm-6 m-3">
            <div class="form-group">
                <label for="">Email</label>
                <input type="email" v-model="creds.email" class="form-control" placeholder="email">
            </div>
            <div class="form-group">
                <label for="">Password</label>
                <input type="password" v-model="creds.password" class="form-control" placeholder="password">
            </div>
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register" class="col-10 offset-1 col-sm-6 m-3">
            <div class="form-group">
                <label for="">Username</label>
                <input type="text" v-model="newUser.username" class="form-control" placeholder="name">
            </div>
            <div class="form-group">
                <label for="">Email</label>
                <input type="email" v-model="newUser.email" class="form-control" placeholder="email">
            </div>
            <div class="form-group">
                <label for="">Password</label>
                <input type="text" v-model="newUser.password" class="form-control" placeholder="password">
            </div>
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm" class="text-center">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {

        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>