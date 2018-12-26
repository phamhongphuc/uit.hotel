<template>
    <div id="side" class="center">
        <div class="left flex-fill" />
        <nuxt class="right" />
    </div>
</template>
<style lang="scss">
#side {
    position: fixed;
    height: 100%;
    width: 100%;
    display: flex;
    > .left {
        background-image: url('/img/background.jpg');
        background-size: cover;
    }
    > .right {
        width: 350px;
    }
}
</style>
