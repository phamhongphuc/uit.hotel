<template>
    <div class="navbar-hr" />
</template>
<style lang="scss">
.navbar-hr {
    width: calc(100% + #{map-get($spacers, 2) * 2});
    background-color: $border-color;
    height: 1.5px;
    display: block;
    margin: 0 -#{map-get($spacers, 2)};
}
</style>
