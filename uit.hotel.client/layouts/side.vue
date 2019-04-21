<template>
    <div id="side" class="center">
        <no-ssr>
            <notifications
                :duration="1500"
                animation-type="velocity"
                position="left bottom"
            />
        </no-ssr>
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
