<template>
    <div id="side" class="center">
        <no-ssr>
            <notifications :duration="1500" position="left bottom" />
        </no-ssr>
        <div class="left flex-fill" />
        <nuxt class="right" />
    </div>
</template>
<style lang="scss">
#side {
    position: fixed;
    display: flex;
    width: 100%;
    height: 100%;
    > .left {
        background-image: url('/img/background.jpg');
        background-size: cover;
    }
    > .right {
        width: 350px;
    }
}
</style>
